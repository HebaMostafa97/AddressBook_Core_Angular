import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateaddressbookComponent } from './updateaddressbook.component';

describe('UpdateaddressbookComponent', () => {
  let component: UpdateaddressbookComponent;
  let fixture: ComponentFixture<UpdateaddressbookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateaddressbookComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateaddressbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
