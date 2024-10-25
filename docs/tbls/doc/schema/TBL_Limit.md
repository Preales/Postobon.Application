# TBL_Limit

## Description

## Columns

| Name | Type | Default | Nullable | Children | Parents | Comment |
| ---- | ---- | ------- | -------- | -------- | ------- | ------- |
| Id | int |  | false |  |  |  |
| NGroupCode | int |  | false |  |  |  |
| NCompanyCode | int |  | false |  |  |  |
| NMacroSegmentCode | int |  | true |  |  |  |
| NTypologyCode | int |  | true |  |  |  |
| NRegionCode | int |  | true |  |  |  |
| NCDICode | int |  | true |  |  |  |
| DCreationDate | datetime |  | false |  |  |  |
| SCreationUser | varchar(300) |  | false |  |  |  |
| DModificationDate | datetime |  | true |  |  |  |
| SModificationUser | varchar(300) |  | true |  |  |  |
| BDeleted | bit |  | false |  |  |  |

## Constraints

| Name | Type | Definition |
| ---- | ---- | ---------- |
| PK_TBL_Limit | PRIMARY KEY | CLUSTERED, unique, part of a PRIMARY KEY constraint, [ Id ] |

## Indexes

| Name | Definition |
| ---- | ---------- |
| PK_TBL_Limit | CLUSTERED, unique, part of a PRIMARY KEY constraint, [ Id ] |

## Relations

![er](TBL_Limit.svg)

---

> Generated by [tbls](https://github.com/k1LoW/tbls)