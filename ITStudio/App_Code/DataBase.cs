﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class admins
{
    public int id { get; set; }
    public string name { get; set; }
    public string password { get; set; }
}

public partial class applications
{
    public int id { get; set; }
    public string name { get; set; }
    public bool gender { get; set; }
    public string major { get; set; }
    public string tel { get; set; }
    public System.DateTime time { get; set; }
    public string job { get; set; }
    public string introduction { get; set; }
}

public partial class members
{
    public members()
    {
        this.workmap = new HashSet<workmap>();
    }

    public int id { get; set; }
    public string name { get; set; }
    public int grade { get; set; }
    public string photo { get; set; }
    public string job { get; set; }
    public string direction { get; set; }
    public string introduction { get; set; }
    public string others { get; set; }

    public virtual ICollection<workmap> workmap { get; set; }
}

public partial class notices
{
    public int id { get; set; }
    public string title { get; set; }
    public System.DateTime time { get; set; }
    public string content { get; set; }
}

public partial class workmap
{
    public int id { get; set; }
    public int memberId { get; set; }
    public int workId { get; set; }

    public virtual members members { get; set; }
    public virtual works works { get; set; }
}

public partial class works
{
    public works()
    {
        this.workmap = new HashSet<workmap>();
    }

    public int id { get; set; }
    public int typeId { get; set; }
    public string title { get; set; }
    public string time { get; set; }
    public string picture { get; set; }
    public string link { get; set; }
    public string introduction { get; set; }

    public virtual ICollection<workmap> workmap { get; set; }
}

public partial class workTypes
{
    public int id { get; set; }
    public string name { get; set; }
}
