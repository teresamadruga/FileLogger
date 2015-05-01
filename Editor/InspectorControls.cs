﻿// Copyright (c) 2015 Bartłomiej Wołk (bartlomiejwolk@gmail.com)
//  
// This file is part of the FileLogger extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using System;
using UnityEngine;

namespace FileLogger {

    public static class InspectorControls {

        /// <summary>
        ///     Draws logger start/stop button. Button text depends on context.
        /// </summary>
        /// <param name="oldLoggingEnabledValue"></param>
        /// <param name="enableOnPlay"></param>
        /// <param name="stateChangedCallback">
        ///     Callback executed on every state change.
        /// </param>
        /// <param name="pauseCallback">
        ///     Callback executed only in play mode, when on logger pause.
        /// </param>
        /// <param name="disableLoggerCallback">
        ///     Callback executed on logger disable.
        /// </param>
        /// <returns></returns>
        public static bool DrawStartStopButton(
            bool oldLoggingEnabledValue,
            bool enableOnPlay,
            Action stateChangedCallback,
            Action pauseCallback,
            Action disableLoggerCallback) {

            // Editor mode, logging disabled.
            if (!Application.isPlaying && !oldLoggingEnabledValue) {
                var newLoggingEnabledValue = GUILayout.Toggle(
                    oldLoggingEnabledValue,
                    "Logging Disabled",
                    "Button");

                // If value was changed..
                if (newLoggingEnabledValue != oldLoggingEnabledValue) {
                    // Execute callback.
                    if (stateChangedCallback != null) {
                        stateChangedCallback();
                    }
                }

                return newLoggingEnabledValue;
            }

            // Play mode, logger enabled.
            if (Application.isPlaying
                && enableOnPlay
                && oldLoggingEnabledValue) {

                var newLoggingEnabledValue = GUILayout.Toggle(
                    oldLoggingEnabledValue,
                    "Logging Enabled",
                    "Button");

                // If value was changed..
                if (newLoggingEnabledValue != oldLoggingEnabledValue) {
                    if (stateChangedCallback != null) {
                        stateChangedCallback();
                    }

                    if (pauseCallback != null) {
                        pauseCallback();
                    }
                }

                return newLoggingEnabledValue;
            }

            // Play mode, logging disabled.
            if (Application.isPlaying
                && enableOnPlay
                && !oldLoggingEnabledValue) {

                var newLoggingEnabledValue = GUILayout.Toggle(
                    oldLoggingEnabledValue,
                    "Logging Paused",
                    "Button");

                // If value was changed..
                if (newLoggingEnabledValue != oldLoggingEnabledValue) {
                    if (stateChangedCallback != null) {
                        stateChangedCallback();
                    }
                }

                return newLoggingEnabledValue;
            }

            // Editor mode, logger enabled.
            if (!Application.isPlaying && oldLoggingEnabledValue) {
                var newLoggingEnabledValue = GUILayout.Toggle(
                    oldLoggingEnabledValue,
                    "Logging Enabled",
                    "Button");

                // If value was changed..
                if (newLoggingEnabledValue != oldLoggingEnabledValue) {
                    if (stateChangedCallback != null) {
                        stateChangedCallback();
                    }

                    if (disableLoggerCallback != null) {
                        disableLoggerCallback();
                    }
                }

                return newLoggingEnabledValue;
            }

            return oldLoggingEnabledValue;
        }

    }

}