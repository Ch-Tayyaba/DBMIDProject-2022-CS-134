

-- Insert sample data into Clo table
INSERT INTO [dbo].[Clo] ([Name], [DateCreated], [DateUpdated]) VALUES 
  (N'CLO 1', '2022-02-01', '2022-02-05'),
  (N'CLO 2', '2022-02-02', '2022-02-06'),
  (N'CLO 3', '2022-02-03', '2022-02-07');

-- Insert sample data into ClassAttendance table
INSERT INTO [dbo].[ClassAttendance] ([AttendanceDate]) VALUES 
  ('2022-02-10'),
  ('2022-02-12'),
  ('2022-02-15');

-- Insert sample data into Assessment table
INSERT INTO [dbo].[Assessment] ([Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES 
  (N'Lab 1', '2022-02-20', 30, 100),
  (N'Lab 2', '2022-02-25', 25, 100),
  (N'Lab 3', '2022-03-01', 35, 100);

-- Insert sample data into Rubric table
INSERT INTO [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES 
  (1, N'Design Rubric for CLO 1', 1),
  (2, N'Execution Rubric for CLO 1', 1),
  (3, N'Testing Rubric for CLO 1', 1),
  (4, N'Design Rubric for CLO 2', 2),
  (5, N'Execution Rubric for CLO 2', 2),
  (6, N'Testing Rubric for CLO 2', 2);

-- Insert sample data into Student table
INSERT INTO [dbo].[Student] ([FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES 
  (N'John', N'Doe', N'123-456-7890', N'john.doe@example.com', '2022001', 5),
  (N'Jane', N'Smith', N'987-654-3210', N'jane.smith@example.com', '2022002', 5),
  (N'Michael', N'Johnson', N'555-555-5555', N'michael.johnson@example.com', '2022003', 5);

-- Insert sample data into RubricLevel table
INSERT INTO [dbo].[RubricLevel] ([RubricId], [Details], [MeasurementLevel]) VALUES 
  (1, N'Exceptional', 4),
  (2, N'Good', 3),
  (3, N'Fair', 2),
  (4, N'Unsatisfactory', 1),
  (5, N'Exceptional', 4),
  (6, N'Good', 3);

-- Insert sample data into AssessmentComponent table
INSERT INTO [dbo].[AssessmentComponent] ([Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES 
  (N'Design', 1, 10, '2022-02-20', '2022-02-21', 1),
  (N'Execution', 2, 10, '2022-02-20', '2022-02-21', 1),
  (N'Testing', 3, 10, '2022-02-20', '2022-02-21', 1),
  (N'Design', 4, 8, '2022-02-25', '2022-02-26', 2),
  (N'Execution', 5, 8, '2022-02-25', '2022-02-26', 2),
  (N'Testing', 6, 9, '2022-02-25', '2022-02-26', 2);

-- Insert sample data into StudentAttendance table
INSERT INTO [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES 
  (1, 1, 1),
  (1, 2, 1),
  (1, 3, 1),
  (2, 1, 2),
  (2, 2, 1),
  (2, 3, 1),
  (3, 1, 1),
  (3, 2, 3),
  (3, 3, 1);



  -- Insert sample data into StudentResult table
INSERT INTO [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES 
  (3, 3, 3, '2022-02-22'),
  (4, 4, 4, '2022-02-27'),
  (5, 5, 5, '2022-02-27'),
  (6, 6, 6, '2022-02-27'),
  (7, 7, 7, '2022-02-28'),
  (8, 8, 8, '2022-02-28');
