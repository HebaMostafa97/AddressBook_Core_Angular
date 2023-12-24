import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeaddressbookComponent } from './homeaddressbook.component';

describe('HomeaddressbookComponent', () => {
  let component: HomeaddressbookComponent;
  let fixture: ComponentFixture<HomeaddressbookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeaddressbookComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeaddressbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
