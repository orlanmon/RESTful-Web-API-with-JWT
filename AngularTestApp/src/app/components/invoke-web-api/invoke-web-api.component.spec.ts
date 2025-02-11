import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvokeWebAPIComponent } from './invoke-web-api.component';

describe('InvokeWebAPIComponent', () => {
  let component: InvokeWebAPIComponent;
  let fixture: ComponentFixture<InvokeWebAPIComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InvokeWebAPIComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvokeWebAPIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
