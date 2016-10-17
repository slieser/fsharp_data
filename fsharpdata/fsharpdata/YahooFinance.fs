namespace yahoofinance

open FSharp.Data
type Stocks = CsvProvider<"http://ichart.finance.yahoo.com/table.csv?s=AAPL">

module public YahooFinance =
    let baseurl = "http://ichart.finance.yahoo.com/table.csv?s="

    let public Load symbol =
        let url = "http://ichart.finance.yahoo.com/table.csv?s=" + symbol
        let stock = Stocks.Load(url)

        [for row in stock.Rows -> row.Date, row.Close]
