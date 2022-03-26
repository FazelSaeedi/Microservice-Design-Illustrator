import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupProjectComponent } from './group-project.component';

describe('GroupProjectComponent', () => {
  let component: GroupProjectComponent;
  let fixture: ComponentFixture<GroupProjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupProjectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
