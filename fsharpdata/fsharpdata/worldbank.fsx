System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
#load "../packages/FsLab.0.3.16/FsLab.fsx"
open FSharp.Data

let wb = WorldBankData.GetDataContext()

printfn "%s" wb.Countries.Germany.CapitalCity

printfn "%s" wb.Countries.Germany.Indicators.``Account at a formal financial institution (% age 15+)``.Description

printfn "%f" wb.Countries.Germany.Indicators.``Account at a formal financial institution (% age 15+)``.[2014]
// NaN

printfn "%A" wb.Countries.Germany.Indicators.``Account at a formal financial institution (% age 15+)``.Years
// 2011

printfn "%f" wb.Countries.Germany.Indicators.``Account at a formal financial institution (% age 15+)``.[2011]
//oder
printfn "%A" wb.Countries.Germany.Indicators.``Account at a formal financial institution (% age 15+)``.Values

wb.Countries.Germany.Indicators |> Seq.map (printfn "%A")

