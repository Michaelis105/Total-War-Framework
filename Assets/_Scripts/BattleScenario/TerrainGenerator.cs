using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

	public int length = 4000;
	public int width = 4000;
	public int height = 300;

	public float scale = 20f;

	public float offsetX = 0f;
	public float offsetY = 0f;

	// Use this for initialization
	void Start() {
		offsetX = Random.Range (0f, 9999f);
		offsetY = Random.Range (0f, 9999f);
		Terrain t = GetComponent<Terrain> ();
		t.terrainData = GenerateTerrain (t.terrainData);
	}
		
	/**
	 * Generates terrain
	 **/
	TerrainData GenerateTerrain(TerrainData td) {
		td.heightmapResolution = width + 1;

		td.size = new Vector3 (width, height, length);
		td.SetHeights(0,0, GenerateHeights());
		// TODO: Apply textures
		// TODO: Apply grass, trees, and other flora
		// TODO: Apply skybox
		return td;
	}

	/**
	 * Generates terrain heights
	 **/
	float[,] GenerateHeights() {
		float[,] heights = new float[width, length];
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < length; y++) {
				heights [x, y] = CalculateHeight (x, y);
			}
		}
		return heights;
	}

	/**
	 * Use Perlin Noise to return height at specific point
	 **/
	float CalculateHeight(int x, int y) {
		float newX = (float) x / width * scale + offsetX;
		float newY = (float) y / length * scale + offsetY;
		return Mathf.PerlinNoise (newX, newY);
	}

}
