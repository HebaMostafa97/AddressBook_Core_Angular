import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomejobComponent } from './homejob.component';

describe('HomejobComponent', () => {
  let component: HomejobComponent;
  let fixture: ComponentFixture<HomejobComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomejobComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomejobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
