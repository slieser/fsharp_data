namespace fsharpdata

open System.Windows.Forms

module demomain =

    [<EntryPoint>]
    let main argv = 
        let chart = Demo.plot("XWD.TO")
        Application.Run(chart)
        0

