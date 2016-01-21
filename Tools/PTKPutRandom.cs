/*
The MIT License (MIT)

Copyright (c) 2015 Samuel LEMAITRE

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using UnityEditor;
using UnityEngine;

public class PTKPutRandom : EditorWindow
{
	public int count = 1;
	public GameObject myObject = null;
	public GameObject myParent = null;
	public Vector3 min = Vector3.zero;
	public Vector3 max = Vector3.zero;
	private Vector3 mi = Vector3.zero;
	private Vector3 ma = Vector3.zero;

	[MenuItem("Tools/PonyToolKit/Put random 3D")]
	private static void Init()
	{
		EditorWindow.GetWindow (typeof(PTKPutRandom));
	}

	void OnGUI()
	{
		count = EditorGUILayout.IntField ("Number of element to put", count);
		myObject = EditorGUILayout.ObjectField ("Object to put", myObject, typeof(GameObject), true) as GameObject;
		myParent = EditorGUILayout.ObjectField ("Parent", myParent, typeof(GameObject), true) as GameObject;
		mi = EditorGUILayout.Vector3Field ("Min zone", mi);
		ma = EditorGUILayout.Vector3Field ("Max zone", ma);
		min = new Vector3 (Math.Min (mi.x, ma.x), Math.Min (mi.y, ma.y), Math.Min (mi.z, ma.z));
		max = new Vector3 (Math.Max (mi.x, ma.x), Math.Max (mi.y, ma.y), Math.Max (mi.z, ma.z));
		if (GUILayout.Button("PutRandom")) putRandom();
		if (GUILayout.Button("Quit")) this.Close();
	}

	void putRandom(){
		GameObject go;
		for (int i = 0; i < count; i++) {
			go = Instantiate (myObject, getRandomVector3(), Quaternion.identity) as GameObject;
			go.transform.SetParent(myParent.transform);
		}
		this.Close ();
	}

	Vector3 getRandomVector3()
	{
		return new Vector3 (UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
	}
}