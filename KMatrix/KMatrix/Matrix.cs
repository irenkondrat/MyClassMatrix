using System;
using System.Globalization;
using System.Text;

namespace KMatrix
{
    public class Matrix:IFormattable, IEquatable<Matrix>
    {
        /// <summary>
        /// Elements of the matrix
        /// </summary>
        public int[,] Elements { get; }

        /// <summary>
        /// Returns count of columns in the matrix
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Returns count of rows in the matrix
        /// </summary>
        public int Width { get; set; }

        private int _elementLength;

        private int _elementWidth;

        /// <summary>
        /// Constructor class 
        /// </summary>
        /// <param name="length">Count of columns</param>
        /// <param name="width">Count of rows </param>
        public Matrix(int length, int width)
        {
            Elements= new int[length,width];
            Length = length;
            Width = width;
            _elementWidth = 0;
            _elementLength = 0;
        }

        /// <summary>
        /// Adding elements in a matrix
        /// </summary>
        /// <param name="values"></param>
        public void Add(int values)
        {
            if (_elementWidth >= Width - 1&& _elementLength>=Length)
            {
                ArgumentException argEx = new ArgumentException("Index is out of range", "index");
                throw argEx;
            }
            if (_elementWidth >= Width - 1 && _elementLength >= Length)
            {

            }
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current object
        /// </summary>
        /// <param name="other">second matrixe</param>
        /// <returns></returns>
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
        /// <summary>
        /// Adds two matrixe
        /// </summary>
        /// <param name="firstMatrix">First matrixe</param>
        /// <param name="secondMatrix">Secon matrixe</param>
        /// <returns></returns>
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
        /// <summary>
        /// Subtracts two matrixes
        /// </summary>
        /// <param name="firstMatrix">First matrixe</param>
        /// <param name="secondMatrix">Secon matrixe</param>
        /// <returns></returns>
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
        /// <summary>
        /// Multiplies the matrix by the number
        /// </summary>
        /// <param name="firstMatrix">First matrixe</param>
        /// <param name="value">Number</param>
        /// <returns></returns>
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
        /// <summary>
        /// Multiplies two matrixes
        /// </summary>
        /// <param name="firstMatrix">First matrixe</param>
        /// <param name="secondMatrix">Secon matrixe</param>
        /// <returns></returns>
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
        /// <summary>
        /// Returns a new square matrix as current transposed matrix
        /// </summary>
        /// <returns>New matrix</returns>
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
