import { Component, OnInit, Input, HostListener, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { StaffApiService } from '../staff-api.service';
@Component({
  selector: 'app-add-form',
  templateUrl: './add-form.component.html',
  styleUrls: ['./add-form.component.css']
})
export class AddFormComponent implements OnInit {

  constructor(private staffApiService: StaffApiService) { }

  ngOnInit(): void {
  }

  @ViewChild('sForm', { static: false }) sForm: NgForm;
  @ViewChild('staffModal') staffModal: ElementRef;
  @Input() type: string;
  @Output() reload: EventEmitter<any> = new EventEmitter<any>();
  visible: boolean = false;
  selectedStaff: any;
  staff: any;
  staffType: number;
  fullName: string;
  dateJoined: Date;
  department: string;
  role: string;
  category: string;
  subject: string;
  task: string;

  SetFormVisible = () => {
    this.visible = true;
    this.staffModal.nativeElement.style.display="block";
  }

  setTask(operation): void {
    this.task = operation;
  }
  readStaff = (task: string) => {
    if (this.type == "admin") {
      this.staff = {
        dateJoined: this.dateJoined,
        department: this.department,
        fullName: this.fullName,
        role: this.role,
        staffType: 2
      }
    }

    if (this.type == "support") {
      this.staff = {
        dateJoined: this.dateJoined,
        category: this.category,
        fullName: this.fullName,
        staffType: 3
      }
    }

    if (this.type == "teaching") {
      this.staff = {
        dateJoined: this.dateJoined,
        subject: this.subject,
        fullName: this.fullName,
        staffType: 1
      }
    }
    if (this.task == "add") {
      console.log(this.staff);
      this.staffApiService.addStaff(this.staff).subscribe(() => this.reload.emit());
    }
    else if (this.task == "edit") {
      console.log(this.staff);
      this.staffApiService.editStaff(this.selectedStaff['staffId'], this.staff).subscribe(() => this.reload.emit());
    }
    this.sForm.resetForm("");
  }

  editStaffData(id) {
    this.staffApiService.getStaffById(id).subscribe(data => {
      this.selectedStaff = data;
      this.fullName=this.selectedStaff['fullName'];
      this.dateJoined= this.selectedStaff['dateJoined'];
      if (this.selectedStaff['staffType'] == 1) {
        this.subject= this.selectedStaff['subject'];
      }
      if (this.selectedStaff['staffType'] == 3) {
        this.category = this.selectedStaff['category'];
      }
      if (this.selectedStaff['staffType'] == 2) {
        this.department= this.selectedStaff['department'];
        this.role = this.selectedStaff['role'];
      }

    });

  }
  
  @HostListener('document:click', ['$event']) onDocumentClick(event) {
    if (event.target == document.getElementById("addFormModal")) {
      this.staffModal.nativeElement.style.display="none";
    }
  }

  closeModal = () => {
    this.staffModal.nativeElement.style.display="none";
  }

  editData(id:string):void{

    this.SetFormVisible();
    this.setTask("edit");
    this.editStaffData(id);
  }

  addData():void{
    this.SetFormVisible();
    this.setTask("add");
  }

}
