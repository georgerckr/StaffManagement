import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffSelectorComponent } from './staff-selector.component';

describe('StaffSelectorComponent', () => {
  let component: StaffSelectorComponent;
  let fixture: ComponentFixture<StaffSelectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StaffSelectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StaffSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
