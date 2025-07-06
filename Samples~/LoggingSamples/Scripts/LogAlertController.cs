using skner.Logging.Loggers;
using skner.Logging.Models;
using System.Collections;
using UnityEngine;

namespace skner.Logging.Demo
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class LogAlertController : MonoBehaviour
    {

        private SpriteRenderer _spriteRenderer;
        private Color _defaultColor;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultColor = _spriteRenderer.color;
            GlobalLogger.Instance.OnLogMessage += (logContext) => { StopAllCoroutines(); StartCoroutine(LogAlert(logContext)); };
        }

        private IEnumerator LogAlert(LogContext logContext)
        {
            _spriteRenderer.color = logContext.LogLevel.DisplayColor;
            yield return new WaitForSeconds(1);
            _spriteRenderer.color = _defaultColor;
        }
    }
}