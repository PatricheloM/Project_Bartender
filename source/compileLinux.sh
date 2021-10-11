#!/bin/bash
preferedResolution=$(awk '{print $1}' <<< $(tail -n1 <<< $(head -n4 <<< $(xrandr))))
currentResolution=$(xdpyinfo | awk '/dimensions/{print $2}')
mainMonitor=$(cut -f6 -d' ' <<< $(xrandr --listactivemonitors))
csc *.cs -r:System.Windows.Forms.dll
xrandr --output $mainMonitor --mode $preferedResolution
mono main.exe &
sleep 1
xrandr --output $mainMonitor --mode $currentResolution