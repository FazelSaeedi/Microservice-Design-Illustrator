import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePageDialogComponent } from './create-page-dialog.component';

describe('CreatePageDialogComponent', () => {
  let component: CreatePageDialogComponent;
  let fixture: ComponentFixture<CreatePageDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatePageDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatePageDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
