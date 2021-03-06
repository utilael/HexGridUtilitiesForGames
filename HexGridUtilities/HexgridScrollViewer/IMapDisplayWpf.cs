﻿#region The MIT License - Copyright (C) 2012-2014 Pieter Geerkens
/////////////////////////////////////////////////////////////////////////////////////////
//                PG Software Solutions Inc. - Hex-Grid Utilities
/////////////////////////////////////////////////////////////////////////////////////////
// The MIT License:
// ----------------
// 
// Copyright (c) 2012-2013 Pieter Geerkens (email: pgeerkens@hotmail.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, 
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to 
// permit persons to whom the Software is furnished to do so, subject to the following 
// conditions:
//     The above copyright notice and this permission notice shall be 
//     included in all copies or substantial portions of the Software.
// 
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//     EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//     OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
//     NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
//     HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
//     WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
//     FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
//     OTHER DEALINGS IN THE SOFTWARE.
/////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System.Windows;
using System.Windows.Media;

using PGNapoleonics.HexUtilities;
using PGNapoleonics.HexUtilities.Common;

namespace PGNapoleonics.HexgridScrollViewer {
  using HexRectF  = System.Drawing.RectangleF;

  /// <summary>(Technology-dependent portion of) interface contract required of a map board to be displayed by the Hexgrid control.</summary>
  public interface IMapDisplayWpf : IMapDisplay {

    /// <summary>Gets the CoordsRectangle description of the clipping region.</summary>
    /// <param name="point">Upper-left corner in pixels of the clipping region.</param>
    /// <param name="size">Width and height of the clipping region in pixels.</param>
    CoordsRectangle GetClipInHexes(Point point, Size size);
    /// <summary>Gets the CoordsRectangle description of the clipping region.</summary>
    /// <param name="visibleClipBounds">Rectangular extent in pixels of the clipping region.</param>
    CoordsRectangle GetClipInHexes(HexRectF visibleClipBounds);

    /// <summary>Paint the top layer of the display, graphics that changes frequently between refreshes.</summary>
    /// <param name="dc">Graphics object for the canvas being painted.</param>
    void  PaintHighlight(DrawingContext graphics);

    /// <summary>Paint the base layer of the display, graphics that changes rarely between refreshes.</summary>
    /// <param name="dc">Type: Graphics - Object representing the canvas being painted.</param>
    /// <remarks>For each visible hex: perform <c>paintAction</c> and then draw its hexgrid outline.</remarks>
    void  PaintMap(DrawingContext graphics);
    /// <summary>Paint the intermediate layer of the display, graphics that changes infrequently between refreshes.</summary>
    /// <param name="dc">Type: Graphics - Object representing the canvas being painted.</param>
    void  PaintUnits(DrawingContext graphics);
  }
}

namespace PGNapoleonics.HexgridScrollViewer {
  using HexPoint  = System.Drawing.Point;
  using HexPointF = System.Drawing.PointF;
  using HexSize   = System.Drawing.Size;
  using HexSizeF  = System.Drawing.SizeF;
  using HexRectF  = System.Drawing.RectangleF;

  using WpfPoint  = System.Windows.Point;
  using WpfSize   = System.Windows.Size;

  public static partial class PointExtensions {
    public static HexPoint ToHexPoint(this WpfPoint @this) {
      return new HexPoint((int)@this.X, (int)@this.Y);
    }
    public static WpfPoint ToWpfPoint(this HexPoint @this) {
      return new WpfPoint(@this.X, @this.Y);
    }
    public static WpfPoint ToWpfPoint(this HexPointF @this) {
      return new WpfPoint(@this.X,@this.Y);
    }
  }

  public static partial class SizeExtensions {
    public static HexSize ToHexSize(this WpfSize @this) {
      return new HexSize((int)@this.Width, (int)@this.Height);
    }
    public static WpfSize ToWpfSize(this HexSize @this) {
      return new WpfSize(@this.Width, @this.Height);
    }
    public static WpfSize ToWpfSize(this HexSizeF @this) {
      return new WpfSize(@this.Width, @this.Height);
    }
  }
}
