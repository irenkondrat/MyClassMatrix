using System;
using System.Globalization;
using System.Text;

namespace KMatrix
{
    public class Matrix:IFormattable, IEquatable<Matrix>
    {
        private int[,] Elements { get; }

        public int Length { get; set; }

        public int Width { get; set; }

        public Matrix(int length, int width)
        {
            Elements= new int[length,width];
            Length = length;
            Width = width;
        }

        public bool Equals(Matrix other)
        {
            if (other != null && (Length!= other.Length  || Width != other.Width))
            {
                return false;
            }
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (other != null && Elements[i,j]!=other.Elements[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            return ToString("", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
           StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    stringBuilder.Append($"{Elements[i, j]}  ");
                }
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.Length != secondMatrix.Length || firstMatrix.Width != secondMatrix.Width)
            {
                ArgumentException argEx = new ArgumentException("Indices are not equal at intervals", $"index");
                throw argEx;
            }
            Matrix resuitMatrix = new Matrix(firstMatrix.Length, firstMatrix.Width);
            for (int i = 0; i < resuitMatrix.Length; i++)
            {
                for (int j = 0; j < resuitMatrix.Width; j++)
                {
                    resuitMatrix.Elements[i, j] = firstMatrix.Elements[i, j] + secondMatrix.Elements[i, j];
                }
            }
            return resuitMatrix;
        }

        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.Length != secondMatrix.Length || firstMatrix.Width != secondMatrix.Width)
            {
                ArgumentException argEx = new ArgumentException("Indices are not equal at intervals", "" + "index");
                throw argEx;
            }
            Matrix resuitMatrix = new Matrix(firstMatrix.Length, firstMatrix.Width);
            for (int i = 0; i < resuitMatrix.Length; i++)
            {
                for (int j = 0; j < resuitMatrix.Width; j++)
                {
                    resuitMatrix.Elements[i, j] = firstMatrix.Elements[i, j] - secondMatrix.Elements[i, j];
                }
            }
            return resuitMatrix;
        }

        public static Matrix operator *(Matrix firstMatrix, int value)
        {
            Matrix resuitMatrix = new Matrix(firstMatrix.Length, firstMatrix.Width);
            for (int i = 0; i < resuitMatrix.Length; i++)
            {
                for (int j = 0; j < resuitMatrix.Width; j++)
                {
                    resuitMatrix.Elements[i, j] = firstMatrix.Elements[i, j] * value;
                }
            }
            return resuitMatrix;
        }

        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix resuitMatrix = new Matrix(firstMatrix.Length, firstMatrix.Width);
            for (int i = 0; i < resuitMatrix.Length; i++)
            {
                for (int j = 0; j < resuitMatrix.Width; j++)
                {
                    resuitMatrix.Elements[i, j] = 0;
                    for (int k = 0; k < resuitMatrix.Width; k++)
                        resuitMatrix.Elements[i, j] += (firstMatrix.Elements[i, k] * secondMatrix.Elements[k, j]);
                }
            }
            return resuitMatrix;
        }

        public Matrix Transpose()
        {
            Matrix resuitMatrix = new Matrix( Width, Length);
            for (int i = 0; i < resuitMatrix.Length; i++)
            {
                for (int j = 0; j < resuitMatrix.Width; j++)
                {
                    resuitMatrix.Elements[i, j] = Elements[j, i];
                }
            }
            return resuitMatrix;
        }
    }
}
