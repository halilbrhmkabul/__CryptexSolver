using UnityEngine;
using FSA = UnityEngine.Serialization.FormerlySerializedAsAttribute;

namespace Lean.Common
{
	/// <summary>This component allows you to translate the specified GameObject when you call methods like <b>TranslateA</b>, which can be done from events.</summary>
	[HelpURL(LeanHelper.PlusHelpUrlPrefix + "LeanManualTranslate")]
	[AddComponentMenu(LeanHelper.ComponentPathPrefix + "Manual Translate")]
	public class LeanManualTranslate : MonoBehaviour
	{
		
		/// <summary>Clamp the X axis?</summary>
		
		public bool X { set { xLocalPosition = value; } get { return xLocalPosition; } }
		[FSA("X")] [Header("Clamp the Local Position")] [Header("	Added by Lerp Games")] [SerializeField] private bool xLocalPosition;

 

		public float XMin { set { xMin = value; } get { return xMin; } }
		[FSA("XMin")] [SerializeField] private float xMin = -1.0f;

		public float XMax { set { xMax = value; } get { return xMax; } }
		[FSA("XMax")] [SerializeField] private float xMax = 1.0f;

		/// <summary>Clamp the Y axis?</summary>
		public bool Y { set { yLocalPosition = value; } get { return yLocalPosition; } }
		[FSA("Y")] [SerializeField] private bool yLocalPosition;

		public float YMin { set { yMin = value; } get { return yMin; } }
		[FSA("YMin")] [SerializeField] private float yMin = -1.0f;

		public float YMax { set { yMax = value; } get { return yMax; } }
		[FSA("YMax")] [SerializeField] private float yMax = 1.0f;

		/// <summary>Clamp the Z axis?</summary>
		public bool Z { set { zLocalPosition = value; } get { return zLocalPosition; } }
		[FSA("Z")] [SerializeField] private bool zLocalPosition;

		public float ZMin { set { zMin = value; } get { return zMin; } }
		[FSA("ZMin")] [SerializeField] private float zMin = -1.0f;

		public float ZMax { set { zMax = value; } get { return zMax; } }
		[FSA("ZMax")] [SerializeField] private float zMax = 1.0f;

		//==========================================

		public Transform ObjectRotation { set { objectRotation = value; } get { return objectRotation; } }
		[FSA("ObjectRotation")] [Header("Local Rotate the Object (from Delta X)")] [SerializeField] private Transform objectRotation;


		public bool XR { set { xLocalRotate = value; } get { return xLocalRotate; } }
		[FSA("XR")] [SerializeField] private bool xLocalRotate;


		public float XRMax { set { xrMax = value; } get { return xrMax; } }
		[FSA("XRMax")] [SerializeField] private float xrMax = 15.0f;

		public bool YR { set { yLocalRotate = value; } get { return yLocalRotate; } }
		[FSA("YR")] [SerializeField] private bool yLocalRotate;


		public float YRMax { set { yrMax = value; } get { return yrMax; } }
		[FSA("YRMax")] [SerializeField] private float yrMax = 15.0f;

		public bool ZR { set { zLocalRotate = value; } get { return zLocalRotate; } }
		[FSA("ZR")] [SerializeField] private bool zLocalRotate;


		public float ZRMax { set { zrMax = value; } get { return zrMax; } }
		[FSA("ZRMax")] [SerializeField] private float zrMax = 15.0f;

		public float MarginRotate { set { marginRotate = value; } get { return marginRotate; } }
		[FSA("MarginRotate")] [SerializeField] private float marginRotate = 15.0f;
		//================================================================================


		/// <summary>If you want this component to work on a different GameObject, then specify it here. This can be used to improve organization if your GameObject already has many components.</summary>
		public GameObject Target { set { target = value; } get { return target; } } [FSA("Target")] [SerializeField] private GameObject target;

		/// <summary>This allows you to set the coordinate space the translation will use.</summary>
		public Space Space { set { space = value; } get { return space; } } [FSA("Space")] [SerializeField] private Space space;

		/// <summary>The first translation direction, used when calling TranslateA or TranslateAB.</summary>
		public Vector3 DirectionA { set { directionA = value; } get { return directionA; } } [FSA("DirectionA")] [SerializeField] private Vector3 directionA = Vector3.right;

		/// <summary>The first second direction, used when calling TranslateB or TranslateAB.</summary>
		public Vector3 DirectionB { set { directionB = value; } get { return directionB; } } [FSA("DirectionB")] [SerializeField] private Vector3 directionB = Vector3.up;

		/// <summary>The translation distance is multiplied by this.
		/// 1 = Normal distance.
		/// 2 = Double distance.</summary>
		public float Multiplier { set { multiplier = value; } get { return multiplier; } } [FSA("Multiplier")] [SerializeField] private float multiplier = 1.0f;

		/// <summary>If you want this component to change smoothly over time, then this allows you to control how quick the changes reach their target value.
		/// -1 = Instantly change.
		/// 1 = Slowly change.
		/// 10 = Quickly change.</summary>
		public float Damping { set { damping = value; } get { return damping; } } [FSA("Dampening")] [SerializeField] private float damping = 10.0f;

		/// <summary>If you enable this then the translation will be multiplied by Time.deltaTime. This allows you to maintain frame rate independent movement.</summary>
		public bool ScaleByTime { set { scaleByTime = value; } get { return scaleByTime; } } [FSA("ScaleByTime")] [SerializeField] private bool scaleByTime;

		/// <summary>If you call the ResetPosition method, the position will be set to this.</summary>
		public Vector3 DefaultPosition { set { defaultPosition = value; } get { return defaultPosition; } } [FSA("DefaultPosition")] [SerializeField] private Vector3 defaultPosition;

		[SerializeField]
		private Vector3 remainingDelta;

		/// <summary>This method will reset the position to the specified DefaultPosition value.</summary>
		[ContextMenu("Reset Position")]
		public void ResetPosition()
		{
			var finalTransform = target != null ? target.transform : transform;
			var oldPosition    = finalTransform.localPosition;

			if (space == Space.Self)
			{
				finalTransform.localPosition = defaultPosition;
			}
			else
			{
				finalTransform.position = defaultPosition;
			}

			remainingDelta = finalTransform.localPosition - oldPosition;

			// Revert
			finalTransform.localPosition = oldPosition;
		}

		/// <summary>This method will cause the position to immediately snap to its final value.</summary>
		[ContextMenu("Snap To Target")]
		public void SnapToTarget()
		{
			UpdatePosition(1.0f);
		}

		/// <summary>This method allows you to translate along DirectionA, with the specified multiplier.</summary>
		public void TranslateA(float magnitude)
		{
			Translate(directionA * magnitude);
		}

		/// <summary>This method allows you to translate along DirectionB, with the specified multiplier.</summary>
		public void TranslateB(float magnitude)
		{
			Translate(directionB * magnitude);
		}

		/// <summary>This method allows you to translate along DirectionA and DirectionB, with the specified multipliers.</summary>
		public void TranslateAB(Vector2 magnitude)
		{
			Translate(directionA * magnitude.x + directionB * magnitude.y);
		}

		/// <summary>This method allows you to translate along the specified vector in local space.</summary>
		public void Translate(Vector3 vector)
		{
			if (space == Space.Self)
			{
				var finalTransform = target != null ? target.transform : transform;

				vector = finalTransform.TransformVector(vector);
			}

			TranslateWorld(vector);
		}

		/// <summary>This method allows you to translate along the specified vector in world space.</summary>
		public void TranslateWorld(Vector3 vector)
		{
			if (scaleByTime == true)
			{
				vector *= Time.deltaTime;
			}

			remainingDelta += vector * multiplier;
		}

		protected virtual void Update()
		{
			var factor = LeanHelper.GetDampenFactor(damping, Time.deltaTime);

			UpdatePosition(factor);
		}

        private void OnEnable()
        {
			ResetPosition();
        }

        private void OnDisable()
        {
			ResetPosition();
        }
        private void UpdatePosition(float factor)
		{

			var finalTransform = target != null ? target.transform : transform;
			var newDelta       = Vector3.Lerp(remainingDelta, Vector3.zero, factor);

			finalTransform.position += remainingDelta - newDelta;

			remainingDelta = newDelta;

			


			//========================================== 
			if (xLocalPosition)
            {
				transform.localPosition = new Vector3(
					Mathf.Clamp(transform.localPosition.x,XMin,xMax),
					transform.localPosition.y,
					transform.localPosition.z);
            }

            if (yLocalPosition)
            {
				transform.localPosition = new Vector3(
					transform.localPosition.x,
					Mathf.Clamp(transform.localPosition.y, YMin, YMax),
					transform.localPosition.z);
			}

			if (zLocalPosition)
			{
				transform.localPosition = new Vector3(
					transform.localPosition.x,
						transform.localPosition.y,
					Mathf.Clamp(transform.localPosition.z, ZMin, ZMax));
			}

			//newDelta *= 1500;
			//==========================================
			if (xLocalRotate)
			{
				if (newDelta.x > .1f)
				{
					//objectRotation.localEulerAngles = new Vector3(XRMax * Time.deltaTime * MarginRotate, 0,0);

					objectRotation.localRotation = Quaternion.Slerp(objectRotation.localRotation, Quaternion.Euler(XRMax * Time.deltaTime * MarginRotate, objectRotation.localRotation.y, objectRotation.localRotation.z), .051f);

					//this.transform.parent.localRotation = Quaternion.Euler(0, 15, 0);
					//this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(XRMax * Time.deltaTime *MarginRotate, 0 , 0), .051f);
				}
				else if (newDelta.x < -.1f)
				{
					//objectRotation.localEulerAngles = new Vector3(-XRMax * Time.deltaTime * MarginRotate, 0, 0);

					objectRotation.localRotation = Quaternion.Slerp(objectRotation.localRotation, Quaternion.Euler(-XRMax * Time.deltaTime * MarginRotate, objectRotation.localRotation.y, objectRotation.localRotation.z), .051f);

					// this.transform.parent.localRotation = Quaternion.Euler(0, -15,0);
					//this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(-XRMax * Time.deltaTime * MarginRotate, 0, 0), .051f);
				}
				else
				{
				//	objectRotation.localEulerAngles = new Vector3(0, 0, 0);

					objectRotation.localRotation = Quaternion.Slerp(objectRotation.localRotation, Quaternion.Euler(0, 0, 0), .11f);


					//this.transform.parent.localRotation = Quaternion.Euler(0, 0, 0);
					//this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0), .051f);

				}
			}

			if (yLocalRotate)
			{
				if (newDelta.x > .1f)
				{
					//objectRotation.localEulerAngles = new Vector3(objectRotation.localEulerAngles.x, YRMax * Time.deltaTime * MarginRotate, 0);

					objectRotation.localRotation = Quaternion.Slerp(objectRotation.localRotation, Quaternion.Euler( objectRotation.localRotation.x, YRMax * Time.deltaTime * MarginRotate, objectRotation.localRotation.z), .15f);




					//this.transform.parent.localRotation = Quaternion.Euler(0, 15, 0);
					//this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, YRMax*Time.deltaTime * MarginRotate, 0), .051f);
				}
				else if (newDelta.x < -.1f)
				{
				//	objectRotation.localEulerAngles = new Vector3(objectRotation.localEulerAngles.x, -YRMax * Time.deltaTime * MarginRotate, 0);


					objectRotation.localRotation = Quaternion.Slerp(objectRotation.localRotation, Quaternion.Euler(objectRotation.localRotation.x, -YRMax * Time.deltaTime * MarginRotate, objectRotation.localRotation.z), .15f);



					// this.transform.parent.localRotation = Quaternion.Euler(0, -15,0);
					//this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, -YRMax * Time.deltaTime * MarginRotate, 0), .051f);
				}
				else
				{
					//objectRotation.localEulerAngles = new Vector3(objectRotation.localEulerAngles.x, 0, 0); 


					objectRotation.localRotation = Quaternion.Slerp(objectRotation.localRotation, Quaternion.Euler(0, 0, 0), .15f);



					//this.transform.parent.localRotation = Quaternion.Euler(0, 0, 0);
					//this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0), .051f);

				}

			}

			if (zLocalRotate)
			{
				if (newDelta.x > .1f)
				{
					//objectRotation.localEulerAngles = new Vector3(objectRotation.localEulerAngles.x, 0, ZRMax * Time.deltaTime * MarginRotate);

					objectRotation.localRotation = Quaternion.Slerp(objectRotation.localRotation, Quaternion.Euler(objectRotation.localRotation.x, objectRotation.localRotation.y, ZRMax * Time.deltaTime * MarginRotate), .051f);



					//this.transform.parent.localRotation = Quaternion.Euler(0, 15, 0);
					//this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, ZRMax * Time.deltaTime * MarginRotate), .051f);
				}
				else if (newDelta.x < -.1f)
				{
					//objectRotation.localEulerAngles = new Vector3(objectRotation.localEulerAngles.x, 0, -ZRMax * Time.deltaTime * MarginRotate);


					objectRotation.localRotation = Quaternion.Slerp(objectRotation.localRotation, Quaternion.Euler(objectRotation.localRotation.x, objectRotation.localRotation.y, -ZRMax * Time.deltaTime * MarginRotate), .051f);



					// this.transform.parent.localRotation = Quaternion.Euler(0, -15,0);
					//this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, -ZRMax * Time.deltaTime * MarginRotate), .051f);
				}
				else
				{
					//objectRotation.localEulerAngles = new Vector3(objectRotation.localEulerAngles.x, 0, 0);


					objectRotation.localRotation = Quaternion.Slerp(objectRotation.localRotation, Quaternion.Euler(0, 0, 0), .11f);



					//this.transform.parent.localRotation = Quaternion.Euler(0, 0, 0);
					//this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0), .051f);

				}
			}




		}
	}
}

#if UNITY_EDITOR
namespace Lean.Common.Editor
{
	using TARGET = LeanManualTranslate;

	[UnityEditor.CustomEditor(typeof(TARGET))]
	public class LeanManualTranslate_Editor : LeanEditor
	{
		protected override void OnInspector()
		{
			TARGET tgt; TARGET[] tgts; GetTargets(out tgt, out tgts);


			Draw("target", "If you want this component to work on a different GameObject, then specify it here. This can be used to improve organization if your GameObject already has many components.");
			Draw("space", "This allows you to set the coordinate space the translation will use.");
			Draw("directionA", "The first translation direction, used when calling TranslateA or TranslateAB.");
			Draw("directionB", "The first translation direction, used when calling TranslateB or TranslateAB.");
			Draw("scaleByTime", "If you enable this then the translation will be multiplied by Time.deltaTime. This allows you to maintain frame rate independent movement.");
			Draw("damping", "If you want this component to change smoothly over time, then this allows you to control how quick the changes reach their target value.\n\n-1 = Instantly change.\n\n1 = Slowly change.\n\n10 = Quickly change.");
			Draw("defaultPosition", "If you call the ResetPosition method, the position will be set to this.");
			Separator();
			Separator();

			Draw("multiplier", "The translation distance is multiplied by this.\n\n1 = Normal distance.\n\n2 = Double distance.");



			Separator();
			Separator();
			Draw("xLocalPosition", "Clamp the X axis?");
			if (Any(tgts, t => t.X == true))
			{
				BeginIndent();
				Draw("xMin", "", "Min");
				Draw("xMax", "", "Max");
				EndIndent();
			}

			Draw("yLocalPosition", "Clamp the Y axis?");
			if (Any(tgts, t => t.Y == true))
			{
				BeginIndent();
				Draw("yMin", "", "Min");
				Draw("yMax", "", "Max");
				EndIndent();
			}

			Draw("zLocalPosition", "Clamp the Z axis?");
			if (Any(tgts, t => t.Z == true))
			{
				BeginIndent();
				Draw("zMin", "", "Min");
				Draw("zMax", "", "Max");
				EndIndent();
			}



			Separator();
			Draw("objectRotation", "Rotate olacak görsel objeyi buraya sürükle. (Rotasyonun stabil çalýþmasý için objeye bir hareket verilmemeli)");

			Draw("xLocalRotate", "Rotate the X axis?");
			if (Any(tgts, t => t.XR == true))
			{
				BeginIndent();
				Draw("xrMax", "", "Rotate Angle");
				EndIndent();
			}

			Draw("yLocalRotate", "Rotate the Y axis?");
			if (Any(tgts, t => t.YR == true))
			{
				BeginIndent();
				Draw("yrMax", "", "Rotate Angle");
				EndIndent();
			}

			Draw("zLocalRotate", "Rotate the Z axis?");
			if (Any(tgts, t => t.ZR == true))
			{
				BeginIndent();
				Draw("zrMax", "", "Rotate Angle");
				EndIndent();
			}


			if (Any(tgts, t => t.ZR == true || t.YR==true || t.XR==true))
				Draw("marginRotate", "Variable", "-> Margin Number for Rotate ");
				
		}
	}
}
#endif