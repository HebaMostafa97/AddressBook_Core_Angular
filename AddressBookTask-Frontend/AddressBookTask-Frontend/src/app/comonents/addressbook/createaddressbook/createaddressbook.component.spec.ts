import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateaddressbookComponent } from './createaddressbook.component';

describe('CreateaddressbookComponent', () => {
  let component: CreateaddressbookComponent;
  let fixture: ComponentFixture<CreateaddressbookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateaddressbookComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateaddressbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
