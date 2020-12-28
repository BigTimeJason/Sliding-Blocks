using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImageSlicer
{
    //Static class as there only needs to be one
    public static Texture2D[,] GetSlices(Texture2D image, int blocksPerLine)
    {
        //make sure the image is a square
        int imageSize = Mathf.Min(image.width, image.height);

        //block size proportionate to the number of blocks per line
        int blockSize = imageSize / blocksPerLine;

        //array of textures containing slices of the image for each block
        Texture2D[,] blocks = new Texture2D[blocksPerLine, blocksPerLine];

        //for each block in the puzzle, we get pixels starting from (x, y) ending at (x + blocksize, y + blocksize)
        for(int y = 0; y < blocksPerLine; y++)
        {
            for(int x = 0; x < blocksPerLine; x++)
            {
                Texture2D block = new Texture2D(blockSize, blockSize);
                block.wrapMode = TextureWrapMode.Clamp;
                block.SetPixels(image.GetPixels(x * blockSize, y * blockSize, blockSize, blockSize));
                block.Apply();

                //add the texture to the array
                blocks[x, y] = block;
            }
        }
        return blocks;
    }
}
