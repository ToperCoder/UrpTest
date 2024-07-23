using UnityEngine;
using System.Collections;
 
    namespace Pathfinding {

	public class BotAnimation : MonoBehaviour {
		
		public Animator anim;
		bool isAtDestination;

		IAstarAI ai;
		Transform tr;
		
		AIDestinationSetter aiDest;

		protected void Awake () {
			aiDest = GetComponent<AIDestinationSetter>();
			ai = GetComponent<IAstarAI>();
			tr = GetComponent<Transform>();
		}

		protected Vector3 lastTarget;

		void OnTargetReached () {
            anim.SetTrigger("Dance");
			lastTarget = tr.position;

			SaveLoadIntJson save = aiDest.target.GetComponent<SaveLoadIntJson>();
			save.SaveInt(1);
			
			Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
		}
        
		protected void Update () {

			if (ai.reachedEndOfPath) {
				if (!isAtDestination) OnTargetReached();
				isAtDestination = true;
			} else isAtDestination = false;

			Vector3 relVelocity = tr.InverseTransformDirection(ai.velocity);
			relVelocity.y = 0;

			anim.SetFloat("NormalizedSpeed", relVelocity.magnitude / anim.transform.lossyScale.x);
		}
	}
}