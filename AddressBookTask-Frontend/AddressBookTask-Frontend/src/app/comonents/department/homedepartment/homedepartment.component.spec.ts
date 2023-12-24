import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomedepartmentComponent } from './homedepartment.component';

describe('HomedepartmentComponent', () => {
  let component: HomedepartmentComponent;
  let fixture: ComponentFixture<HomedepartmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomedepartmentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomedepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
