namespace fsharpdata

open FSharp.Charting
open FSharp.Data

type Stocks = CsvProvider<"http://ichart.finance.yahoo.com/table.csv?s=AAPL">

module public Demo =
    let url = "http://ichart.finance.yahoo.com/table.csv?s=AAPL"
    let stock = Stocks.Load(url)

    let public plot = 
        [ for row in stock.Rows -> row.Date, row.Open ]
        |> Chart.Line
 