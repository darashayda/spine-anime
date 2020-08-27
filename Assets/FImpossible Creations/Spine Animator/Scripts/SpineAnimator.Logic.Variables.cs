﻿using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FSpine
{
    public partial class FSpineAnimator
    {

        #region Hierarchy Icon

        public string EditorIconPath { get { return "Spine Animator/SpineAnimator_SmallIcon"; } }
        public void OnDrop(UnityEngine.EventSystems.PointerEventData data) { }

        #endregion


        #region MAIN CALCULATIONS VARIABLES

        /// <summary> Depends of bones' hierarchy structure, sometimes you will need leading bone in reversed position than default, this variable will help handling it in code </summary>
        private int leadingBoneIndex;

        /// <summary> Helper variable to reverse some variables when using reversed spine feature </summary>
        private int chainIndexDirection = 1;
        private int chainIndexOffset = 1;
        //private int chainIndexCountAdjust = 0;


        #endregion


        #region Extra helper variables

        /// <summary> Computed delta time for current frame </summary>
        protected float delta = 0.016f;
        /// <summary> Delta for lerp(a,b,dt) operations </summary>
        protected float unifiedDelta = 0.016f;
        /// <summary> Helper for calculating stable delta calculations </summary>
        protected float elapsedDeltaHelper = 0f;
        /// <summary> How many udpate loops should be done according to stable update rate </summary>
        protected int updateLoops = 1;

        /// <summary> Flag to define if component was initialized already for more controll </summary>
        private bool initialized = false;

        /// <summary> Variable to calculate difference in last frame position to current, needed for some straigtening calculations when bone is in move</summary>
        private Vector3 previousPos;

        bool wasBlendedOut = false;

        /// <summary> If we want to sync some wrong hierarched bones </summary>
        private List<FSpineBoneConnector> connectors;

        private float referenceDistance = 0.1f;

        public Vector3 ModelForwardAxis = Vector3.forward;
        public Vector3 ModelForwardAxisScaled = Vector3.forward;
        public Vector3 ModelUpAxis = Vector3.up;
        public Vector3 ModelUpAxisScaled = Vector3.up;
        internal Vector3 ModelRightAxis = Vector3.right;
        internal Vector3 ModelRightAxisScaled = Vector3.right;

        #endregion

    }
}