import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-bill-list",
  templateUrl: "./bill-list.component.html",
  styleUrls: ["./bill-list.component.css"],
})
export class BillListComponent implements OnInit {
  displayedColumns: string[] = ["Name", "Amount[PLN]", "Who Paid", "Date"];
  dataSource: any[] = [];

  constructor() {}

  ngOnInit(): void {}
}
