/**********************************************************************************
* Blueprint Reality Inc. CONFIDENTIAL
* 2018 Blueprint Reality Inc.
* All Rights Reserved.
*
* NOTICE:  All information contained herein is, and remains, the property of
* Blueprint Reality Inc. and its suppliers, if any.  The intellectual and
* technical concepts contained herein are proprietary to Blueprint Reality Inc.
* and its suppliers and may be covered by Patents, pending patents, and are
* protected by trade secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Blueprint Reality Inc.
***********************************************************************************/

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
using UnityEngine;

namespace BlueprintReality.MixCast
{
    public class BaseEventHandler : MonoBehaviour
    {
        protected virtual string Category { get { return "BaseEventChangeMe"; } }

        protected virtual void HandleEvent(EventCenter.Result result, string locMsg)
        {
            switch (result)
            {
                case EventCenter.Result.Started: HandleStarted(locMsg); break;
                case EventCenter.Result.Stopped: HandleStopped(locMsg); break;
                case EventCenter.Result.Success: HandleSuccess(locMsg); break;
                case EventCenter.Result.Error: HandleError(locMsg); break;
            }
        }

        protected virtual void HandleError(string msg) { }
        protected virtual void HandleStarted(string msg) { }
        protected virtual void HandleStopped(string msg) { }
        protected virtual void HandleSuccess(string msg) { }

        void OnEnable()
        {
            EventCenter.AddListener(Category, HandleEvent);
        }

        void OnDisable()
        {
            EventCenter.RemoveListener(Category, HandleEvent);
        }
    }
}
#endif
