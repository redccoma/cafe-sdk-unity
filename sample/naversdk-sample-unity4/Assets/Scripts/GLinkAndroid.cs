// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class GLinkAndroid : IGLink {
	#if UNITY_ANDROID
	AndroidJavaClass mGLinkClass = null;
	AndroidJavaObject mCurrentActivity = null;

	class OnClickAppSchemeBannerListener : AndroidJavaProxy {
		public OnClickAppSchemeBannerListener () : base("com.naver.glink.android.sdk.Glink$OnClickAppSchemeBannerListener") { /* empty. */ }
		
		void onClickAppSchemeBanner (string appScheme) {
			var activity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject> ("currentActivity");
			activity.Call ("runOnUiThread", new AndroidJavaRunnable (() => {
				AndroidJavaObject toast = new AndroidJavaClass ("android.widget.Toast").CallStatic<AndroidJavaObject>("makeText", activity, appScheme, 1);
				toast.Call ("show");
			}));
		}
	}

	class OnSdkStartedListener : AndroidJavaProxy {
		public OnSdkStartedListener () : base("com.naver.glink.android.sdk.Glink$OnSdkStartedListener") { /* empty. */ }

		void onSdkStarted () {
			var activity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject> ("currentActivity");
			activity.Call ("runOnUiThread", new AndroidJavaRunnable (() => {
				AndroidJavaObject toast = new AndroidJavaClass ("android.widget.Toast").CallStatic<AndroidJavaObject>("makeText", activity, "sdk start.", 1);
				toast.Call ("show");
			}));
		}
	}

	class OnSdkStoppedListener : AndroidJavaProxy {
		public OnSdkStoppedListener () : base("com.naver.glink.android.sdk.Glink$OnSdkStoppedListener") { /* empty. */ }

		void onSdkStopped () {
			var activity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject> ("currentActivity");
			activity.Call ("runOnUiThread", new AndroidJavaRunnable (() => {
				AndroidJavaObject toast = new AndroidJavaClass ("android.widget.Toast").CallStatic<AndroidJavaObject>("makeText", activity, "sdk stop.", 1);
				toast.Call ("show");
			}));
		}
	}
	#endif

	public GLinkAndroid () {
		#if UNITY_ANDROID
		mCurrentActivity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject> ("currentActivity");
		mGLinkClass = new AndroidJavaClass ("com.naver.glink.android.sdk.Glink");
		mGLinkClass.CallStatic ("init", GLinkConfig.NaverLoginClientId, GLinkConfig.NaverLoginClientSecret, GLinkConfig.CafeId);

		// 앱스킴 listener 사용 하려면 아래 주석을 풀어 주세요.
		mGLinkClass.CallStatic ("setOnClickAppSchemeBannerListener", new OnClickAppSchemeBannerListener ());

		// sdk start listener 사용 하려면 아래 주석을 풀어 주세요.
		mGLinkClass.CallStatic ("setOnSdkStartedListener", new OnSdkStartedListener ());

		// sdk stop listener 사용 하려면 아래 주석을 풀어 주세요.
		mGLinkClass.CallStatic ("setOnSdkStoppedListener", new OnSdkStoppedListener ());

		// 게임 아이디 연동을 하려면 아래 주석을 풀어 주세요.
		// mGLinkClass.CallStatic ("setGameUserId", mCurrentActivity, "197CymaStoevCg", "");
		#endif
	}
	
	public void executeMain() {
		#if UNITY_ANDROID
		mGLinkClass.CallStatic("startHome", mCurrentActivity);
		#endif
	}
	
	public void executeArticlePost(int menuId, string subject, string content) {
		#if UNITY_ANDROID
		mGLinkClass.CallStatic ("startWrite", mCurrentActivity, menuId, subject, content);
		#endif
	}
	
	public void executeArticlePostWithImage(int menuId, string subject, string content, string filePath) {
		#if UNITY_ANDROID
		mGLinkClass.CallStatic ("startImageWrite", mCurrentActivity, menuId, subject, content, "file://" + filePath);
		#endif
	}
	
	public void executeArticlePostWithVideo(int menuId, string subject, string content, string filePath) {
		#if UNITY_ANDROID
		mGLinkClass.CallStatic ("startVideoWrite", mCurrentActivity, subject, content, "file://" + filePath);
		#endif
	}
}


