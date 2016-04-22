
module FSharpFirebase

open FireSharp
open FireSharp.Config

type Todo =
    { Name : string
      Priority : int }

module Db =
    let set(client: FirebaseClient) =
        let todo = { Name = "wk 2"; Priority = 10 }
        let response = client.SetAsync("todo", [todo, todo, todo])
        let rs = response.Result.ResultAs<Todo>()
        printfn "%A" rs

    let push(client: FirebaseClient, todo) =
        let response = client.PushAsync("todo", todo)
        let rs = response.Result.ResultAs<Todo>()
        printfn "%A" rs

    let connect() =
        let config = new FirebaseConfig()
        config.AuthSecret <- "rAtEvka0Bed6hF3tBjOS5WnoDuY1W9QULm4Xv1nF"
        config.BasePath <- "https://torid-heat-8456.firebaseio.com/"
        new FirebaseClient(config)

[<EntryPoint>]
let main argv =

    let conn = Db.connect()
    let range = [1..10]

    let createTodo i =
        async {
            let todo = { Name = "wk 2"; Priority = i }
            Db.push(conn, todo)
            printf "%A" todo
            return 0
        }

    for i in 1..100 do
        let todo = { Name = "wk"; Priority = i }
        Db.push(conn, todo)
        printf "%A" todo
(*
    range
    |> List.map createTodo
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
    *)

    printfn "%A" argv
    0 // return an integer exit code



