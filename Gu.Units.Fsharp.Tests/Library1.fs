namespace Gu.Units.Fsharp.Tests
module Tests=
    [<Measure>]
    type sec
    [<Measure>]
    type kg
    [<Measure>]
    type m
    [<Measure>]
    type inch
    let s = 1.0<m>
    let t = 2.0<sec>    
    let speed = s/t   