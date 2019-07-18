﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumSharp.Backends;

namespace NumSharp
{
    public static partial class np
    {
        /// <summary>
        ///     Broadcast an shape against an other new shape.
        /// </summary>
        /// <param name="from">The shape that is to be broadcasted</param>
        /// <param name="against">The shape that'll be used to broadcast <paramref name="from"/> shape</param>
        /// <returns>A readonly view on the original array with the given shape. It is typically not contiguous. Furthermore, more than one element of a broadcasted array may refer to a single memory location.</returns>
        /// <remarks>https://docs.scipy.org/doc/numpy/reference/generated/numpy.broadcast_to.html</remarks>
        public static Shape broadcast_to(Shape from, Shape against)
        {
            return DefaultEngine.Broadcast(from, against).LeftShape;
        }

        /// <summary>
        ///     Broadcast an array to a new shape.
        /// </summary>
        /// <param name="lhs">An array to broadcast.</param>
        /// <param name="rhs">An array to broadcast.</param>
        /// <returns>These arrays are views on the original arrays. They are typically not contiguous. Furthermore, more than one element of a broadcasted array may refer to a single memory location. If you need to write to the arrays, make copies first.</returns>
        /// <remarks>https://docs.scipy.org/doc/numpy/reference/generated/numpy.broadcast_to.html</remarks>
        public static NDArray broadcast_to(NDArray from, Shape against)
        {
            return new NDArray(UnmanagedStorage.CreateBroadcastedUnsafe(from.Storage, DefaultEngine.Broadcast(from.Shape, against).LeftShape));
        }
    }
}
