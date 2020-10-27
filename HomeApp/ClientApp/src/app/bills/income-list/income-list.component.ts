import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-income-list",
  templateUrl: "./income-list.component.html",
  styleUrls: ["./income-list.component.css"],
})
export class IncomeListComponent implements OnInit {
  displayedColumns: string[] = ["Name", "Amount[PLN]", "Who Paid", "Date"];
  dataSource: any[] = [];
  constructor() {}

  ngOnInit(): void {}
}
