#!/bin/bash
csc *.cs -r:System.Windows.Forms.dll,Newtonsoft.Json.dll
mono main.exe &