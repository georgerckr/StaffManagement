import { Component, OnInit, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { StaffApiService } from '../staff-api.service'
import { AddFormComponent } from '../add-form/add-form.component'

@Component({
  selector: 'app-staff-selector',
  templateUrl: './staff-selector.component.html',
  styleUrls: ['./staff-selector.component.css'],
})
export class StaffSelectorComponent implements OnInit {

  constructor(private staffApiService: StaffApiService) { }

  ngOnInit(): void {

  }
  //@ViewChild(AddFormComponent) addForm: AddFormComponent;
  @ViewChild('sTable') sTable: ElementRef;
  staffs = [];
  headers = [];
  staffType: string;
  table: HTMLTableElement;
  input: HTMLInputElement;
  isChecked: boolean;
 
  getStaffByType(event = null): void {
    if (event != null) {
      this.staffType = event.target.value;
    }

    if (this.staffType == 'admin') {
      this.headers = ["Staff ID", "Name", "Date of Joining", "Department", "Role"];
    }

    if (this.staffType == 'teaching') {
      this.headers = ["Staff ID", "Name", "Date of Joining", "Subject"];
    }

    if (this.staffType == 'support') {
      this.headers = ["Staff ID", "Name", "Date of Joining", "Category"];
    }
    this.staffApiService.getStaffs(this.staffType).subscribe(data => this.staffs = data);
  }

  // addNewStaff(): void {
  //   this.addForm.SetFormVisible();
  //   this.addForm.setTask("add");
  //   this.getStaffByType();
  // }



  deleteRow(): void {
    var idList=[];
    this.table=this.sTable.nativeElement;
    for (var index = 0; index < this.staffs.length; index++) {

      this.input = this.table.rows[index + 1].cells[0].children[0] as HTMLInputElement;
      if (this.input && this.input.checked) {

        idList.push(this.staffs[index]["staffId"]);
      }
    }
    for (var i = 0; i < idList.length; i++) {
      this.deleteStaff(idList[i]);
    }

  }

  deleteStaff(id: string): void {
    this.staffApiService.deleteStaff(id).subscribe(() => this.getStaffByType());
  }

  // editStaff(id: string): void {
  //   this.addForm.SetFormVisible();
  //   this.addForm.setTask("edit");
  //   this.addForm.editStaffData(id);
  // }
}
