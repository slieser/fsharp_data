#r "../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#load "../packages/FSharp.Charting.0.90.13/FSharp.Charting.fsx"
open FSharp.Data
open FSharp.Charting

type Preisindex = CsvProvider<"daten/61111-0004.csv", Separators = ";", Culture = "de-DE">

let preisindex = Preisindex.Load("daten/61111-0004.csv")

for row in Seq.toArray(preisindex.Rows) do
    printfn "%i: %O" row.Jahr row.Januar
