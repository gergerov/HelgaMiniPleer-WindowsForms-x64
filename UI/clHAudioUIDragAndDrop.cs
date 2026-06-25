using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace Pleer.UI;

public class clHAudioUIDragAndDrop
{
    public FlowLayoutPanel FilesLayout;
    public int mx;
    public int my;
    public bool isdrg;
    public TableLayoutPanel? drgpanel;

    public clHAudioUIDragAndDrop(FlowLayoutPanel FilesLayout)
    {
        this.FilesLayout = FilesLayout;
    }

    public void DD_MouseDown(object? sender, MouseEventArgs e)
    {
        
    }

    public void DD_MouseMove(object? sender, MouseEventArgs e)
    {
        
    }
    public void DD_DragEnter(object? sender, DragEventArgs e)
    {
        
    }
}
