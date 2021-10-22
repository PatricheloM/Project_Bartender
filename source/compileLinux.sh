#!/bin/bash
csc *.cs -r:System.Windows.Forms.dll
mono main.exe &