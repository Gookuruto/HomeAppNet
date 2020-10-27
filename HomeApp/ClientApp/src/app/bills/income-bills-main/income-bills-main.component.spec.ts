import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncomeBillsMainComponent } from './income-bills-main.component';

describe('IncomeBillsMainComponent', () => {
  let component: IncomeBillsMainComponent;
  let fixture: ComponentFixture<IncomeBillsMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncomeBillsMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncomeBillsMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
