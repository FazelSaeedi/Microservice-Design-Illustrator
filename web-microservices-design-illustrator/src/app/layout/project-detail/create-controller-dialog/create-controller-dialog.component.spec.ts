import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateControllerDialogComponent } from './create-controller-dialog.component';

describe('CreateControllerDialogComponent', () => {
  let component: CreateControllerDialogComponent;
  let fixture: ComponentFixture<CreateControllerDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateControllerDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateControllerDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
