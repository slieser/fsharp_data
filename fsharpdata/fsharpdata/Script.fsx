System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
#r "../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
open FSharp.Data

type Stocks = CsvProvider<"http://ichart.finance.yahoo.com/table.csv?s=AAPL">

let url = "http://ichart.finance.yahoo.com/table.csv?s=AAPL"
let stock = Stocks.Load(url)

let firstRow = stock.Rows |> Seq.head

let max = stock.Rows |> Seq.maxBy (fun x -> x.Close)

//stock.Rows |> Seq.iter (fun x -> printfn "%A" x)

#r "../packages/FSharp.Charting.Gtk.0.90.12/lib/net40/OxyPlot.dll"
#r "../packages/FSharp.Charting.Gtk.0.90.12/lib/net40/OxyPlot.GtkSharp.dll"
#r "../packages/FSharp.Charting.Gtk.0.90.12/lib/net40/FSharp.Charting.Gtk.dll"
//#load "../packages/FSharp.Charting.Gtk.0.90.12/FSharp.Charting.Gtk.fsx"

open FSharp.Charting

[ for row in stock.Rows -> row.Date, row.Open ]
    |> Chart.Line
