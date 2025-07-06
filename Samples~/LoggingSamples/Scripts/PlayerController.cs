using skner.Logging.Extensions;
using skner.Logging.Loggers;
using skner.Logging.Settings;
using UnityEngine;

namespace skner.Logging.Demo
{
    /// <summary>
    /// A simple player controller, used to showcase logging calls for the various different methods.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D), typeof(GameObjectLogger))]
    public class PlayerController : MonoBehaviour
    {

        public float MoveSpeed = 5.0f;

        private Rigidbody2D _rigidBody;

        private GameObjectLogger _gameObjectLogger;
        private ClassLogger _logger;

        void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();

            _gameObjectLogger = GetComponent<GameObjectLogger>();
            _logger = new ClassLogger(Resources.Load<LoggerSettings>("Logging/ExampleLoggerSettings"));
        }

        void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            var movement = new Vector2(horizontalInput, verticalInput);

            _rigidBody.velocity = movement * MoveSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            switch (collision.gameObject.name)
            {
                case "DebugBox":
                    GlobalLogger.Instance.Log("Trace", "Bumped.");
                    _logger.LogDebug("Bumped.");
                    _gameObjectLogger.LogDebug("Bumped.");
                    break;
                case "WarningBox":
                    GlobalLogger.Instance.LogWarning("Bumped.");
                    _logger.LogWarning("Bumped.");
                    _gameObjectLogger.LogWarning("Bumped.");
                    break;
                case "ErrorBox":
                    GlobalLogger.Instance.LogError("Bumped.");
                    _logger.LogError("Bumped.");
                    _gameObjectLogger.LogError("Bumped.");
                    break;
            }
        }
    }
}