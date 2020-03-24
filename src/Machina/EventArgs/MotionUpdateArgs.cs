﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machina;
using Machina.EventArgs;
using Machina.Types.Geometry;

namespace Machina.EventArgs
{
    //  ███╗   ███╗ ██████╗ ████████╗██╗ ██████╗ ███╗   ██╗   ██╗   ██╗██████╗ ██████╗  █████╗ ████████╗███████╗    █████╗ ██████╗  ██████╗ ███████╗
    //  ████╗ ████║██╔═══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║   ██║   ██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝   ██╔══██╗██╔══██╗██╔════╝ ██╔════╝
    //  ██╔████╔██║██║   ██║   ██║   ██║██║   ██║██╔██╗ ██║   ██║   ██║██████╔╝██║  ██║███████║   ██║   █████╗     ███████║██████╔╝██║  ███╗███████╗
    //  ██║╚██╔╝██║██║   ██║   ██║   ██║██║   ██║██║╚██╗██║   ██║   ██║██╔═══╝ ██║  ██║██╔══██║   ██║   ██╔══╝     ██╔══██║██╔══██╗██║   ██║╚════██║
    //  ██║ ╚═╝ ██║╚██████╔╝   ██║   ██║╚██████╔╝██║ ╚████║██╗╚██████╔╝██║     ██████╔╝██║  ██║   ██║   ███████╗██╗██║  ██║██║  ██║╚██████╔╝███████║
    //  ╚═╝     ╚═╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝
    //                                                                                                                                              
    /// <summary>
    /// Arguments for MotionUpdate events.
    /// </summary>
    public class MotionUpdateArgs : MachinaEventArgs
    {
        /// <summary>
        /// Last known position of the TCP.
        /// </summary>
        public Vector Position { get; }

        /// <summary>
        /// Last known orientation of the TCP.
        /// </summary>
        public Rotation Rotation { get; }

        /// <summary>
        /// Last known robot axes.
        /// </summary>
        public Axes Axes { get; }

        /// <summary>
        /// Last known roobt external axes.
        /// </summary>
        public ExternalAxes ExternalAxes { get; }

        public MotionUpdateArgs(Vector pos, Rotation ori, Axes axes, ExternalAxes extax)
        {
            Position = pos;
            Rotation = ori;
            Axes = axes;
            ExternalAxes = extax;
        }

        public override string ToString() => ToJSONString();

        public override string ToJSONString()
        {
            return string.Format("{{\"event\":\"motion-update\",\"pos\":{0},\"ori\":{1},\"quat\":{2},\"axes\":{3},\"extax\":{4},\"conf\":{5}}}",
                Position?.ToArrayString(MMath.STRING_ROUND_DECIMALS_MM) ?? "null",
                Rotation?.ToOrientation()?.ToArrayString(MMath.STRING_ROUND_DECIMALS_MM) ?? "null",
                Rotation?.Q.ToArrayString(MMath.STRING_ROUND_DECIMALS_QUAT) ?? "null",
                Axes?.ToArrayString(MMath.STRING_ROUND_DECIMALS_DEGS) ?? "null",
                ExternalAxes?.ToArrayString() ?? "null",
                "null");  // placeholder for whenever IK solvers are introduced...
        }
    }
}
