import { Component, OnInit, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { WorkerHoursService,ValidatorsService, WorkerHours } from '../../imports';

@Component({
  selector: 'app-tmp-worker-hours',
  templateUrl: './tmp-worker-hours.component.html',
  styleUrls: ['./tmp-worker-hours.component.css']
})
export class TmpWorkerHoursComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  @Input()
  workerHours: WorkerHours;

  numHoursControl: FormControl;

  //----------------CONSTRUCTOR------------------

  constructor(private workerHoursService: WorkerHoursService, private validatorsService: ValidatorsService) { }

  //----------------METHODS-------------------

  ngOnInit() {
    this.numHoursControl = new FormControl(this.workerHours.numHours, this.validatorsService.stringValidatorArr("num hours", 1));
  }

  changeWorkerHours() {
    this.workerHours.numHours = this.numHoursControl.value;
    this.workerHoursService.changeWorkerHoursSubject.next(this.workerHours);
  }

  deleteWorkerHours() {
    this.workerHoursService.deleteWorkerHoursSubject.next(this.workerHours);
  }
}
