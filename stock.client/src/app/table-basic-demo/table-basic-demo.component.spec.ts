import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableBasicDemoComponent } from './table-basic-demo.component';

describe('TableBasicDemoComponent', () => {
  let component: TableBasicDemoComponent;
  let fixture: ComponentFixture<TableBasicDemoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TableBasicDemoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TableBasicDemoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
