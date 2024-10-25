# TBL_Notification

## Description

## Columns

| Name | Type | Default | Nullable | Children | Parents | Comment |
| ---- | ---- | ------- | -------- | -------- | ------- | ------- |
| SCode | varchar(10) |  | false |  |  |  |
| SName | varchar(20) |  | true |  |  |  |
| BTypeNotificationAutomate | bit |  | true |  |  |  |
| IDaysAmount | int |  | true |  |  |  |
| NNegotiationCompliancePercentage | numeric |  | true |  |  |  |
| SNegotationState | varchar(3) |  | true |  |  |  |
| BIsActive | bit |  | true |  |  |  |
| BDelete | bit |  | true |  |  |  |
| DCreationDate | datetime |  | true |  |  |  |
| SCreationUser | varchar(300) |  | true |  |  |  |
| DModificationDate | datetime |  | true |  |  |  |
| SModificationUser | varchar(300) |  | true |  |  |  |

## Constraints

| Name | Type | Definition |
| ---- | ---- | ---------- |
| PK__TBL_Noti_* | PRIMARY KEY | CLUSTERED, unique, part of a PRIMARY KEY constraint, [ SCode ] |

## Indexes

| Name | Definition |
| ---- | ---------- |
| PK__TBL_Noti_* | CLUSTERED, unique, part of a PRIMARY KEY constraint, [ SCode ] |

## Relations

![er](TBL_Notification.svg)

---

> Generated by [tbls](https://github.com/k1LoW/tbls)