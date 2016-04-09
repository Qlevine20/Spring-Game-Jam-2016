using UnityEngine;

[RequireComponent(typeof(GazePointDataComponent), typeof(UserPresenceComponent), typeof(SpriteRenderer))]
public class Follow : MonoBehaviour
{
	private GazePointDataComponent _gazePointDataComponent;
	private UserPresenceComponent _userPresenceComponent;
	private SpriteRenderer _rendererComponent;

	// Exponential smoothing parameters, alpha must be between 0 and 1.
	[Range(0.1f, 1.0f)]
	public float alpha = 0.3f;
	private Vector2 _historicPoint;
	private bool _hasHistoricPoint;

	void Start ()
	{
		_gazePointDataComponent = GetComponent<GazePointDataComponent>();
		_userPresenceComponent = GetComponent<UserPresenceComponent>();
		_rendererComponent = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
		var lastGazePoint = _gazePointDataComponent.LastGazePoint;

		if (_userPresenceComponent.IsValid && _userPresenceComponent.IsUserPresent && lastGazePoint.IsValid)
		{
			var gazePointInScreenSpace = lastGazePoint.Screen;
			var smoothedGazePoint = Smoothify(gazePointInScreenSpace);

			var gazePointInWorldSpace = Camera.main.ScreenToWorldPoint(
				new Vector3(smoothedGazePoint.x, smoothedGazePoint.y, Camera.main.nearClipPlane));

			transform.position = gazePointInWorldSpace;
			_rendererComponent.enabled = true;
		}
		else
		{
			_rendererComponent.enabled = false;
			_hasHistoricPoint = false;
		}
	}

	private Vector2 Smoothify(Vector2 point)
	{
		if (!_hasHistoricPoint)
		{
			_historicPoint = point;
			_hasHistoricPoint = true;
		}

		var smoothedPoint = new Vector2(point.x*alpha + _historicPoint.x*(1.0f - alpha),
			point.y*alpha + _historicPoint.y*(1.0f - alpha));

		_historicPoint = smoothedPoint;

		return smoothedPoint;
	}
}