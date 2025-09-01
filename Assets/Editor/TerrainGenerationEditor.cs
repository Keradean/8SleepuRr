using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;

[CustomEditor(typeof(TerrainGeneration))]
public class TerrainGenerationEditor : Editor
{
    #region SerializedProperties

    SerializedProperty _seed;
    SerializedProperty _customSeed;
    SerializedProperty _gridSize;
    SerializedProperty _tiles;
    SerializedProperty _grid;

    #endregion

    private bool generationSettings;

    private void OnEnable()
    {
        _seed = serializedObject.FindProperty("_seed");
        _customSeed = serializedObject.FindProperty("_customSeed");
        _gridSize = serializedObject.FindProperty("_gridSize");
        _tiles = serializedObject.FindProperty("_tiles");
        _grid = serializedObject.FindProperty("_grid");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        TerrainGeneration terrainGeneration = (TerrainGeneration)target;


        EditorGUILayout.LabelField("Level Generation", EditorStyles.boldLabel);


        GUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(_customSeed);
        if (_customSeed.boolValue)
        {
            EditorGUILayout.PropertyField(_seed, GUIContent.none);
        }
        else
        {
            EditorGUILayout.LabelField("Seed used: " + _seed.intValue);
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.Separator();


        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate Level"))
        {
            terrainGeneration.generateLevel(_seed.intValue);
        }
        if (GUILayout.Button("Clear Level"))
        {
            terrainGeneration.clearLevel();
        }
        GUILayout.EndHorizontal();

        generationSettings = EditorGUILayout.Foldout(generationSettings, "Settings");
        if (generationSettings)
        {
            EditorGUILayout.PropertyField(_grid);
            EditorGUILayout.PropertyField(_gridSize);
            EditorGUILayout.Separator();
            EditorGUILayout.PropertyField(_tiles);
        }
        

        serializedObject.ApplyModifiedProperties();
    }
}
