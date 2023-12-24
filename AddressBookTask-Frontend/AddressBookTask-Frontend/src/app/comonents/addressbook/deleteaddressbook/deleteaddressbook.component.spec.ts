import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteaddressbookComponent } from './deleteaddressbook.component';

describe('DeleteaddressbookComponent', () => {
  let component: DeleteaddressbookComponent;
  let fixture: ComponentFixture<DeleteaddressbookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteaddressbookComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteaddressbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
