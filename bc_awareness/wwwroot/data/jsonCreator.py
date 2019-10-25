#!/usr/bin/python

import csv, json

csvFilePath = 'mockCSV.csv'
jsonFilePath = 'questions.json'

questions = []
data = {}
with open(csvFilePath, encoding='utf-8-sig') as csvFile:
    csvReader = csv.DictReader(csvFile)
    for rows in csvReader:
        id = rows['id']
        data[id] = rows
for item in data.values():
    questions.append(item)
print(questions)

with open(jsonFilePath, 'w') as jsonFile:
    jsonFile.write(json.dumps(questions,indent =4))

