import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoApiComponent } from './demo-api.component';

describe('DemoApiComponent', () => {
  let component: DemoApiComponent;
  let fixture: ComponentFixture<DemoApiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DemoApiComponent]
    });
    fixture = TestBed.createComponent(DemoApiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
