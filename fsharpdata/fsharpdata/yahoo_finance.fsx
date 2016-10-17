#r "../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#load "../packages/FSharp.Charting.0.90.13/FSharp.Charting.fsx"
open FSharp.Data
open FSharp.Charting

type Stocks = CsvProvider<"http://ichart.finance.yahoo.com/table.csv?s=AAPL">
let baseurl = "http://ichart.finance.yahoo.com/table.csv?s="

let aapl_stock = Stocks.Load(baseurl + "AAPL")
let msft_stock = Stocks.Load(baseurl + "MSFT")

let aapl = [ for row in aapl_stock.Rows -> row.Date, row.Open ]
let msft = [ for row in msft_stock.Rows -> row.Date, row.Open ]

Chart.Combine(
    [
    Chart.Line(aapl)
    Chart.Line(msft)
    ])
